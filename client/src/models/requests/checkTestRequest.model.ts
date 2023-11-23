import { GetUserTestRequest } from "./getUserTests.request.model";

export interface CheckTestRequest extends GetUserTestRequest {
    chosenOptions: string[],
}