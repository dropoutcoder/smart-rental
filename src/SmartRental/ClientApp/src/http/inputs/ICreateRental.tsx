import { IdentificationType } from "../shared/IdentificationType";

export default interface ICreateRental {
    carId: number | null;
    customerId: number | null;
    licenceNumber: string;
    personalDocumentType: IdentificationType | null;
    personalDocumentNumber: number | null;
    pickupDateTime: string;
    price: number | null;
    returnDateTime: string;
}