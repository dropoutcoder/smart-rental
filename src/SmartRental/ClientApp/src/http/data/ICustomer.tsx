import IAddress from "./IAddress";

export default interface ICustomer {
    id: number;
    givenName: string;
    surname: string;
    address: IAddress;
    dateOfBirth: Date;
}