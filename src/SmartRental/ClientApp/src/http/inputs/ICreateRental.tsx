import { IdentificationType } from "../shared/IdentificationType";

export default interface ICreateRental {
    carId: number | undefined;
    customerId: number | undefined;
    licenceNumber: string;
    personalDocumentType: IdentificationType | undefined;
    personalDocumentNumber: number | undefined;
    pickupDateTime: string;
    price: number | undefined;
    returnDateTime: string;
}