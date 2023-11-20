import { useState } from 'react';
import { Button, TextField, Container, Typography, Radio, RadioGroup, FormControlLabel } from '@mui/material';
import { RestClient } from "../../api/rest.client.ts";
import { TokenResponse } from "../../models/auth/token.response.ts";
import { ApiServicesRoutes } from "../../api/api.services.routes.ts";
import { RegisterModel } from "../../models/auth/register.model.ts";
import useToken from '../../hooks/useToken.ts';
import { useNavigate } from 'react-router-dom';
import { Role } from '../../models/common/role.enum.ts';

function RegisterPage() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const { _, setToken } = useToken();
    const navigate = useNavigate();

    const restClient: RestClient = new RestClient();

    const onSubmit = async (event) => {
        event.preventDefault();
        const token = 'test'

        if (token) {
            setToken(token);
            return navigate('/vacancy');
        }
    }

    return (
        <Container maxWidth="sm">
            <Typography variant="h4" align="center" gutterBottom>
                Register
            </Typography>
            <form onSubmit={onSubmit}>
                <TextField
                    label="Email"
                    fullWidth
                    value={email}
                    onChange={(event) => setEmail(event.target.value)}
                    variant="outlined"
                    margin="normal"
                />
                <TextField
                    label="Password"
                    type="password"
                    fullWidth
                    value={password}
                    onChange={(event) => setPassword(event.target.value)}
                    variant="outlined"
                    margin="normal"
                />
                <Button
                    variant="contained"
                    color="primary"
                    fullWidth
                    type="submit"
                    size="large"
                    style={{ marginTop: 16 }}
                >
                    Sign Up
                </Button>
            </form>
        </Container>
    );
}

export default RegisterPage;