import { Component } from 'react';
import ApiClient from '../http/ApiClient';
import { Container } from 'reactstrap';
import IRental from '../http/data/IRental';
import { RentalTable } from '../components/RentalTable';
import CreateRentalForm from '../components/CreateRentalForm';
import ICustomer from '../http/data/ICustomer';
import ICar from '../http/data/ICar';

export class RentalsPage extends Component<{}, { items: Array<IRental>, cars: Array<ICar>, customers: Array<ICustomer>, loading: boolean }> {
    static displayName = RentalsPage.name;

    state = {
        items: [] as Array<IRental>,
        cars: [] as Array<ICar>,
        customers: [] as Array<ICustomer>,
        loading: true
    };
    client = new ApiClient();

    componentDidMount() {
        this.loadCars();
        this.loadCustomers();
        this.loadRentals();
    }

    render() {
        let table = this.state.loading
            ? <p><em>Loading...</em></p>
            : <RentalTable items={this.state.items}></RentalTable>

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
            const items = [...state.items, value];

            return {
                items,
                loading: state.loading,
            };
        });
    }

    async loadRentals() {
        await this.client.getRentals()
            .then(data => this.setState({ items: data, loading: false }))
            .catch(error => alert(error));
    }

    async loadCars() {
        await this.client.getCars()
            .then(data => this.setState({ cars: data }))
            .catch(error => alert(error));
    }

    async loadCustomers() {
        await this.client.getCustomers()
            .then(data => this.setState({ customers: data }))
            .catch(error => alert(error));
    }
}