import { Card, CardContent, Typography, Box, Button } from "@mui/material";
import { UserTestDto } from "../models/tests/userTestDto.model";
import { NavLink } from "react-router-dom";

export interface Props{
    userTest : UserTestDto
}

export function TestPlate({userTest} : Props){
    const formattedCompletionDate =
    userTest.completionDate && new Date(userTest.completionDate).toISOString().replace('T', ' ').replace(/\.\d+Z$/, '');

    return (
        <Card sx={{ display: 'flex', justifyContent: 'space-between', margin: '1rem' }}>
            <CardContent>
                <Typography variant="h5" gutterBottom>
                {userTest.testTitle}
                </Typography>
                {userTest.completionDate && (
                <Typography variant="body2">
                    Completion Date: {formattedCompletionDate}
                </Typography>
                )}
            </CardContent>
            <CardContent>
                {userTest.mark !== null ? (
                <Box
                    sx={{
                    backgroundColor: 'green',
                    color: 'white',
                    padding: '8px',
                    borderRadius: '4px',
                    textAlign: 'center',
                    }}
                >
                    <Typography variant="body1">Mark: {userTest.mark}</Typography>
                </Box>
                ) : (
                <Button variant="contained" color="primary" component={NavLink} to={`/tests/${userTest.testId}`}>
                    Complete
                </Button>
                )}
            </CardContent>
        </Card>
    )
}