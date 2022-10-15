import ICar from "./data/ICar";
import ICustomer from "./data/ICustomer";
import IRental from "./data/IRental";
import ICancelRental from "./inputs/ICancelRental";
import ICreateCar from "./inputs/ICreateCar";
import ICreateCustomer from "./inputs/ICreateCustomer";
import ICreateRental from "./inputs/ICreateRental";

class ApiClient {
    static postOptions = {
        headers: {
            'Content-Type': 'application/json'
        },
        method: 'POST'
    }

    static patchOptions = {
        headers: {
            'Content-Type': 'application/json'
        },
        method: 'PATCH'
    }

    async getCars(): Promise<ICar[]> {
        return await fetch('api/car')
            .then(response => response.json())
            .catch(error => {
                console.log(error);
                throw error;
            });
    }

    async createCar(data: ICreateCar): Promise<ICar> {
        return await fetch('api/car', {
            ...ApiClient.postOptions,
            ...{
                body: JSON.stringify(data)
            }
        })
        .then(response => {
            if (!response.ok) {
                console.log(response.status);
                console.log(response.statusText);
                throw new Error(response.statusText);
            }

            return response.json();
        })
        .catch(error => {
            console.log(error);
            throw error;
        });
    }

    async getCustomers(): Promise<ICustomer[]> {
        return await fetch('api/customer')
            .then(response => response.json())
            .catch(error => {
                console.log(error);
                throw error;
            });
    }

    async createCustomer(data: ICreateCustomer): Promise<ICustomer> {
        return await fetch('api/customer', {
            ...ApiClient.postOptions,
            ...{
                body: JSON.stringify(data)
            }
        })
            .then(response => {
                if (!response.ok) {
                    console.log(response.status);
                    console.log(response.statusText);
                    throw new Error(response.statusText);
                }

                return response.json();
            })
            .catch(error => {
                console.log(error);
                throw error;
            });
    }

    async getRentals(): Promise<IRental[]> {
        return await fetch('api/rental')
            .then(response => response.json())
            .catch(error => {
                console.log(error);
                throw error;
            });
    }

    async createRental(data: ICreateRental): Promise<IRental> {
        return await fetch('api/rental', {
            ...ApiClient.postOptions,
            ...{
                body: JSON.stringify(data)
            }
        })
            .then(response => {
                if (!response.ok) {
                    console.log(response.status);
                    console.log(response.statusText);
                    throw new Error(response.statusText);
                }

                return response.json();
            })
            .catch(error => {
                console.log(error);
                throw error;
            });
    }

    async cancelRental(data: ICancelRental): Promise<boolean> {
        return await fetch('api/rental/cancel', {
            ...ApiClient.patchOptions,
            ...{
                body: JSON.stringify(data)
            }
        })
            .then(response => {
                if (!response.ok) {
                    console.log(response.status);
                    console.log(response.statusText);
                    throw new Error(response.statusText);
                }

                return response.json();
            })
            .catch(error => {
                console.log(error);
                throw error;
            });
    }
}

const Client = new ApiClient();

export default Client;