# UserTestingApp

# Project Startup Instructions

## Start API with Database

1. Navigate to the `UserTestingApi` folder in your project directory.
2. Run the following command in the terminal:

```bash
docker-compose -up --build
```

This command will start the API along with the necessary database components.

3. Make sure you have Docker installed on your machine before running the above command.

## Configure Client

1. Open the `environment.ts` file located at `client\src\environment\environment.ts`.

2. Look for the API URL configuration. If you have changed the default API URL, update it accordingly.

   ```typescript
   export const environment = {
     apiUrl: 'http://your-api-url', // Update this URL
   };
3. In the terminal, navigate to the client folder in your project directory.

4. Run the following command:

```bash
npm run dev
```