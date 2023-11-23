import { createApi } from '@reduxjs/toolkit/query/react';
import { axiosBaseQuery } from "../../../api/axios.baseQuery";
import { environment } from "../../../environment/environment";
import { UserTestDto } from '../../../models/tests/userTestDto.model';
import { ApiServicesRoutes } from '../../../api/api.services.routes';
import { GetUserTestRequest } from '../../../models/requests/getUserTests.request.model';
import { TestDto } from '../../../models/tests/testDto.model';
import { CheckTestRequest } from '../../../models/requests/checkTestRequest.model';


export const testApi = createApi({
    baseQuery: axiosBaseQuery({ baseUrl: environment.apiUrl }),
    endpoints: (builder) => ({
        getTests: builder.query<UserTestDto[], string>({query : (userId : string) => ({ url: `${ApiServicesRoutes.tests}/assignedTests/${userId}`, method: "GET" })}),
        getTest: builder.query<TestDto, GetUserTestRequest>({query : (request : GetUserTestRequest) => ({ url: `${ApiServicesRoutes.tests}/${request.userId}/${request.testId}`, method: "GET" })}),
        checkTest: builder.mutation<UserTestDto, CheckTestRequest>({query : (request : CheckTestRequest) => ({ url: `${ApiServicesRoutes.testChecker}/${request.testId}/${request.userId}`, method: "POST", data: request.chosenOptions })}),
    })   
});

export const { useGetTestsQuery, useGetTestQuery, useCheckTestMutation } = testApi;



