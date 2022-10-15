import { Component } from 'react';
import ApiClient from '../http/ApiClient';
import { Container } from 'reactstrap';
import IRental from '../http/data/IRental';
import { RentalTable } from '../components/RentalTable';
import CreateRentalForm from '../components/CreateRentalForm';
import ICustomer from '../http/data/ICustomer';
import ICar from '../http/data/ICar';

export class RentalsPage extends Component<{}, { rentals: Array<IRental>, cars: Array<ICar>, customers: Array<ICustomer>, loading: boolean }> {
    static displayName = RentalsPage.name;

    state = {
        rentals: [] as Array<IRental>,
        cars: [] as Array<ICar>,
        customers: [] as Array<ICustomer>,
        loading: true
    };

    componentDidMount() {
        this.loadCars();
        this.loadCustomers();
        this.loadRentals();
    }

    render() {
        let table = this.state.loading
            ? <p><em>Loading...</em></p>
            : <RentalTable items={this.state.rentals} onCancelRequested={(id) => this.cancelRental(id)}></RentalTable>

        return (
            <Container>
                <h1>Rentals</h1>
                <CreateRentalForm cars={this.state.cars} customers={this.state.customers} onCreated={(value) => this.addRental(value)} />
                {table}
            </Container>
        );
    }

    addRental(value: IRental): void {
        this.setState(state => {
            const rentals = [...state.rentals, value];

            return {
                rentals,
                loading: state.loading,
            };
        });
    }

    async loadRentals() {
        await ApiClient.getRentals()
            .then(data => this.setState({ rentals: data, loading: false }))
            .catch(error => alert(error));
    }

    async loadCars() {
        await ApiClient.getCars()
            .then(data => this.setState({ cars: data }))
            .catch(error => alert(error));
    }

    async loadCustomers() {
        await ApiClient.getCustomers()
            .then(data => this.setState({ customers: data }))
            .catch(error => alert(error));
    }

    async cancelRental(id: number) {
        await ApiClient.cancelRental({ rentalId: id })
            .then(data => {
                if (data === true) {
                    this.setState(state => {
                        let rentals = state.rentals.map(r => {
                            if (r.id === id) {
                                r.isCancelled = true;
                            }

                            return r;
                        })

                        return {
                            rentals,
                            loading: state.loading,
                        };
                    })
                }
            })
            .catch(error => alert(error));
    }
}