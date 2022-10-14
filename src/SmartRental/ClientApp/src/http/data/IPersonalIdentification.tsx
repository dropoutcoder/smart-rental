import { IdentificationType } from "../shared/IdentificationType";

export default interface IPersonalIdentification {
    number: number;
    personalIdentificationType: IdentificationType;
}