import { useState } from 'react';
import { Button, TextField, Container, Typography, Radio } from '@mui/material';
import { RestClient } from "../../api/rest.client.ts";
import useToken from '../../hooks/useToken.ts';
import { useNavigate } from 'react-router-dom';
import { TokenResponse } from '../../models/auth/token.response.ts';
import { ApiServicesRoutes } from '../../api/api.services.routes.ts';
import { RegisterModel } from '../../models/auth/register.model.ts';

function RegisterPage() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const { _, setToken } = useToken();
    const navigate = useNavigate();

    const restClient: RestClient = new RestClient();

    const onSubmit = async (event) => {
        event.preventDefault();
        const token = await restClient.post<TokenResponse>(ApiServicesRoutes.auth + '/register', { email, password } as RegisterModel);

        if (token) {
            setToken(token);
            return navigate('/');
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