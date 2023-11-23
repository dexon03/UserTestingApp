import { Paper, Typography, FormControl, FormLabel, RadioGroup, FormControlLabel, Radio, Button } from "@mui/material";
import { useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { useCheckTestMutation, useGetTestQuery } from "../../app/features/tests/test.api";
import useToken from "../../hooks/useToken";
import { GetUserTestRequest } from "../../models/requests/getUserTests.request.model";
import { CheckTestRequest } from "../../models/requests/checkTestRequest.model";
import { TestPlate } from "../../components/test.plate";
import { useDispatch } from "react-redux";


function TestCompletionPage() {
    const navigate = useNavigate();
    const { id } = useParams();
    const {token, setToken} = useToken();
    const [selectedOptions, setSelectedOptions] = useState<{ [optionId: string]: string }>({});
    const [
      checkTest,
      result,
    ] = useCheckTestMutation()
    
    const { data, isError, isLoading, error } = useGetTestQuery({
      userId : token!.userId,
      testId : id
    } as GetUserTestRequest);
    
    if (isLoading) {
      return <p>Loading...</p>;
    }

    if (isError) {
        return <p>Error: {error}</p>;
    }

  
    const handleOptionChange = (questionId: string, optionId: string) => {
      setSelectedOptions((prevSelectedOptions) => ({
        ...prevSelectedOptions,
        [questionId]: optionId,
      }));
    };
  
    const handleSubmit = (e) => {
      e.preventDefault();
      console.log('Selected options:', selectedOptions);
      const options = Object.keys(selectedOptions).map((key) => selectedOptions[key]);
      checkTest({
        userId : token!.userId,
        testId : id!,
        chosenOptions : options
      } as CheckTestRequest );
    };

    const onBackButtonClick = () => {
      navigate('/');
    }
  
    return (
      <>
      <Button
        variant="contained"
        color="primary"
        onClick={() => onBackButtonClick()}
        style={{ position: 'absolute', top: 16, left: 16 }}
      >
        Back
      </Button>
      {
        result.data ? <TestPlate userTest={result.data} /> : 
        data &&
        <Paper sx={{ padding: '16px', maxWidth: '600px', margin: 'auto' }}>
          <Typography variant="h4" align="center" gutterBottom>
            {data.title}
          </Typography>
          <form onSubmit={handleSubmit}>
            {data.questions.map((question) => (
              <FormControl component="fieldset" key={question.id} margin="normal" fullWidth>
                <FormLabel component="legend">{question.text}</FormLabel>
                <RadioGroup
                  value={selectedOptions[question.id] || ''}
                  onChange={(e) => handleOptionChange(question.id, e.target.value)}
                >
                  {question.options.map((option) => (
                    <FormControlLabel
                      key={option.id}
                      value={option.id}
                      control={<Radio />}
                      label={option.text}
                    />
                  ))}
                </RadioGroup>
              </FormControl>
            ))}
            <Button type="submit" variant="contained" color="primary" fullWidth>
              Submit
            </Button>
          </form>
        </Paper>
      }
      </>
    );
  }
  
  export default TestCompletionPage;