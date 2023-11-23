import { createBrowserRouter, RouteObject } from "react-router-dom";
import App from "../App";
import LoginPage from "../pages/auth/login.page";
import RegisterPage from "../pages/auth/register.page";
import UserTestListComponent from "../pages/test/test.list";
import TestCompletionPage from "../pages/test/test";

const routes: RouteObject[] = [
    {
        path: "/",
        element: <App />,       
        children:[
            {
                path: '/',
                element: <UserTestListComponent />
            },
            {
                path: '/tests/:id',
                element: <TestCompletionPage />
            }
        ]
    },
    {
        path: '/login',
        element: <LoginPage />
    },
    {
        path: '/register',
        element: <RegisterPage />
    }
    
]

export const router = createBrowserRouter(routes);