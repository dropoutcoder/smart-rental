import { Component } from 'react';
import ApiClient from '../http/ApiClient';
import ICustomer from '../http/data/ICustomer';
import { CustomerTable } from '../components/CustomerTable';
import CreateCustomerForm from '../components/CreateCustomerForm';
import { Container } from 'reactstrap';

export class CustomersPage extends Component<{}, { items: Array<ICustomer>, loading: boolean }> {
    static displayName = CustomersPage.name;

    state = { items: [] as Array<ICustomer>, loading: true };
    client = new ApiClient();

    componentDidMount() {
        this.loadCustomers();
    }

    render() {
        let table = this.state.loading
            ? <p><em>Loading...</em></p>
            : <CustomerTable items={this.state.items}></CustomerTable>

        return (
            <Container>
                <h1>Customers</h1>
                <CreateCustomerForm onCreated={(value) => this.addCustomer(value)} />
                {table}
            </Container>
        );
    }

    addCustomer(value: ICustomer): void {
        this.setState(state => {
            const items = [...state.items, value];

            return {
                items,
                loading: state.loading,
            };
        });
    }

    async loadCustomers() {
        await this.client.getCustomers()
            .then(data => this.setState({ items: data, loading: false }))
            .catch(error => alert(error));
    }
}