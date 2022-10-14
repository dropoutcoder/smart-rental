import IPersonalIdentification from "./IPersonalIdentification";

export default interface IRental {
    id: number;
    carId: number;
    customerId: number;
    isPaid: boolean;
    isCancelled: boolean;
    licenceNumber: string;
    personalDocument: IPersonalIdentification;
    pickupDateTime: Date;
    price: number;
    returnDateTime: Date;
}