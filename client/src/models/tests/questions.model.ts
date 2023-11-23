import { Option } from "./option.model"

export interface Question {
    id: string,
    text: string,
    options : Option[]
}