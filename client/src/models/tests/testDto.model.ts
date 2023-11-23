import { Question } from "./questions.model";

export interface TestDto {
    id: string,
    title : string,
    questions : Question[]
}