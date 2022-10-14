import { ChangeEvent, Component, FormEvent } from "react";
import { Button, Col, Container, Form, Input, InputGroup, InputGroupText, Label, Row } from "reactstrap";
import ApiClient from "../http/ApiClient";
import ICar from "../http/data/ICar";
import ICustomer from "../http/data/ICustomer";
import IRental from "../http/data/IRental";
import ICreateRental from "../http/inputs/ICreateRental";
import { IdentificationType } from "../http/shared/IdentificationType";

export default class CreateRentalForm extends Component<{ cars: Array<ICar>, customers: Array<ICustomer>, onCreated: (value: IRental) => void }, ICreateRental> {
    static defaultState = {
        carId: null,
        customerId: null,
        licenceNumber: '',
        personalDocumentType: null,
        personalDocumentNumber: null,
        pickupDateTime: '',
        price: null,
        returnDateTime: ''
    };

    state = CreateRentalForm.defaultState;

    client = new ApiClient();

    handleCarIdChange(event: ChangeEvent<HTMLInputElement>): void {
        this.setState({
            carId: Number(event.target.value)
        });
    }

    handleCustomerIdChange(event: ChangeEvent<HTMLInputElement>): void {
        this.setState({
            customerId: Number(event.target.value)
        });
    }

    handleLicenceNumberChange(event: ChangeEvent<HTMLInputElement>): void {
        this.setState({
            licenceNumber: event.target.value
        });
    }

    handlePersonalDocumentTypeChange(event: ChangeEvent<HTMLInputElement>): void {
        this.setState({
            personalDocumentType: Number(event.target.value)
        });
    }

    handlePersonalDocumentNumberChange(event: ChangeEvent<HTMLInputElement>): void {
        this.setState({
            personalDocumentNumber: event.target.valueAsNumber
        });
    }

    handlePickupDateTimeChange(event: ChangeEvent<HTMLInputElement>): void {
        this.setState({
            pickupDateTime: event.target.value
        });
    }

    handlePriceChange(event: ChangeEvent<HTMLInputElement>): void {
        this.setState({
            price: event.target.valueAsNumber
        });
    }

    handleReturnDateTimeChange(event: ChangeEvent<HTMLInputElement>): void {
        this.setState({
            returnDateTime: event.target.value
        });
    }

    handleSubmit(event: FormEvent<HTMLFormElement>): void {
        event.preventDefault();

        this.client.createRental(this.state)
            .then(value => {
                console.log(JSON.stringify(value));
                this.props.onCreated(value);
                this.setState(CreateRentalForm.defaultState);
            })
            .catch((error: Error) => {
                alert(error.message);
            });
    }

    render() {
        return (
            <Form onSubmit={(e) => this.handleSubmit(e)}>
                <Container className="d-grid gap-3">
                    <Row>
                        <Col md={6}>
                            <InputGroup>
                                <InputGroupText>
                                    Car
                                </InputGroupText>
                                <Input type="select" placeholder="Select car" value={this.state.carId ?? undefined} onChange={(e) => this.handleCarIdChange(e)}>
                                    <option>Select car</option>
                                    {
                                        this.props.cars.map(car =>
                                            <option value={car.id}>{[car.name, car.registrationNumber].join(' - ')}</option>
                                        )}
                                </Input>
                            </InputGroup>
                        </Col>

                        <Col md={6}>
                            <InputGroup>
                                <InputGroupText>
                                    Customer
                                </InputGroupText>
                                <Input type="select" placeholder="Select customer" value={this.state.customerId ?? undefined} onChange={(e) => this.handleCustomerIdChange(e)}>
                                    <option>Select customer</option>
                                    {
                                        this.props.customers.map(customer =>
                                            <option value={customer.id}>{[customer.givenName, customer.surname].join(' ')}</option>
                                    )}
                                </Input>
                            </InputGroup>
                        </Col>
                    </Row>
                    <Row>
                        <Col md={4}>
                            <InputGroup>
                                <InputGroupText>
                                    Driving licence number
                                </InputGroupText>
                                <Input type="text" placeholder="Enter driving licence number" value={this.state.licenceNumber} onChange={(e) => this.handleLicenceNumberChange(e)} />
                            </InputGroup>
                        </Col>

                        <Col md={4}>
                            <InputGroup>
                                <InputGroupText>
                                    Personal document type
                                </InputGroupText>
                                <Input type="select" placeholder="Select document type" value={this.state.personalDocumentType ?? undefined} onChange={(e) => this.handlePersonalDocumentTypeChange(e)}>
                                    <option>Select document type</option>
                                    <option value={IdentificationType.NationalId}>National ID</option>
                                    <option value={IdentificationType.Passport}>Passport</option>
                                </Input>
                            </InputGroup>
                        </Col>

                        <Col md={4}>
                            <InputGroup>
                                <InputGroupText>
                                    Personal document number
                                </InputGroupText>
                                <Input type="number" placeholder="Enter personal document number" value={this.state.personalDocumentNumber ?? undefined} onChange={(e) => this.handlePersonalDocumentNumberChange(e)} />
                            </InputGroup>
                        </Col>
                    </Row>
                    <Row>
                        <Col md={4}>
                            <InputGroup>
                                <InputGroupText>
                                    Pickup date
                                </InputGroupText>
                                <Input type="date" placeholder="Enter pickup date" value={this.state.pickupDateTime} onChange={(e) => this.handlePickupDateTimeChange(e)} />
                            </InputGroup>
                        </Col>

                        <Col md={4}>
                            <InputGroup>
                                <InputGroupText>
                                    Return date
                                </InputGroupText>
                                <Input type="date" placeholder="Enter return date" value={this.state.returnDateTime} onChange={(e) => this.handleReturnDateTimeChange(e)} />
                            </InputGroup>
                        </Col>

                        <Col md={4}>
                            <InputGroup>
                                <InputGroupText>
                                    Price
                                </InputGroupText>
                                <Input type="number" placeholder="Enter price" value={this.state.price ?? undefined} onChange={(e) => this.handlePriceChange(e)} />
                            </InputGroup>
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <Button variant="primary" type="submit">
                                Create
                            </Button>
                        </Col>
                    </Row>
                </Container>
            </Form>
        );
    }
}