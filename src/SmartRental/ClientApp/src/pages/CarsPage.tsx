import { Component } from 'react';
import ICar from '../http/data/ICar';
import ApiClient from '../http/ApiClient';
import CreateCarForm from '../components/CreateCarForm';
import { CarTable } from '../components/CarTable';
import { Container } from 'reactstrap';

export class CarsPage extends Component<{}, { cars: Array<ICar>, loading: boolean }> {
    static displayName = CarsPage.name;

    state = { cars: [] as Array<ICar>, loading: true };

    componentDidMount() {
        this.loadCars();
    }

    render() {
        let table = this.state.loading
            ? <p><em>Loading...</em></p>
            : <CarTable items={this.state.cars}></CarTable>

        return (
            <Container>
                <h1>Cars</h1>
                <CreateCarForm onCreated={(value) => this.addCar(value) } />
                {table}
            </Container>
        );
    }

    addCar(value: ICar): void {
        this.setState(state => {
            const cars = [...state.cars, value];

            return {
                cars,
                loading: state.loading,
            };
        });
    }

    async loadCars() {
        await ApiClient.getCars()
            .then(data => this.setState({ cars: data, loading: false }))
            .catch(error => alert(error));
    }
}