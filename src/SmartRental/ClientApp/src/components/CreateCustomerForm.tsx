import { ChangeEvent, Component, FormEvent } from "react";
import { Button, Col, Container, Form, Input, InputGroup, InputGroupText, Label, Row } from "reactstrap";
import ApiClient from "../http/ApiClient";
import ICustomer from "../http/data/ICustomer";
import ICreateCustomer from "../http/inputs/ICreateCustomer";

export default class CreateCustomerForm extends Component<{ onCreated: (value: ICustomer) => void }, ICreateCustomer> {
    static defaultState = {
        givenName: '',
        surname: '',
        street: '',
        city: '',
        postalCode: '',
        dateOfBirth: ''
    };

    state = CreateCustomerForm.defaultState;

    client = new ApiClient();

    handleNameChange(event: ChangeEvent<HTMLInputElement>): void {
        this.setState({
            givenName: event.target.value
        });
    }

    handleSurnameChange(event: ChangeEvent<HTMLInputElement>): void {
        this.setState({
            surname: event.target.value
        });
    }

    handleDateOfBirthChange(event: ChangeEvent<HTMLInputElement>): void {
        this.setState({
            dateOfBirth: event.target.value
        });
    }

    handleStreetChange(event: ChangeEvent<HTMLInputElement>): void {
        this.setState({
            street: event.target.value
        });
    }

    handleCityChange(event: ChangeEvent<HTMLInputElement>): void {
        this.setState({
            city: event.target.value
        });
    }

    handlePostalCodeChange(event: ChangeEvent<HTMLInputElement>): void {
        this.setState({
            postalCode: event.target.value
        });
    }

    handleSubmit(event: FormEvent<HTMLFormElement>): void {
        event.preventDefault();

        this.client.createCustomer(this.state)
            .then(value => {
                console.log(JSON.stringify(value));
                this.props.onCreated(value);
                this.setState(CreateCustomerForm.defaultState);
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
                        <Col md={4}>
                            <InputGroup>
                                <InputGroupText>
                                    Given Name
                                </InputGroupText>
                                <Input type="text" placeholder="Enter given name" value={this.state.givenName} onChange={(e) => this.handleNameChange(e)} />
                            </InputGroup>
                        </Col>

                        <Col md={4}>
                            <InputGroup>
                                <InputGroupText>
                                    Surname
                                </InputGroupText>
                                <Input type="text" placeholder="Enter surname" value={this.state.surname} onChange={(e) => this.handleSurnameChange(e)} />
                            </InputGroup>
                        </Col>

                        <Col md={4}>
                            <InputGroup>
                                <InputGroupText>
                                    Date of birth
                                </InputGroupText>
                                <Input type="date" placeholder="Enter date of birth" value={this.state.dateOfBirth} onChange={(e) => this.handleDateOfBirthChange(e)} />
                            </InputGroup>
                        </Col>
                    </Row>
                    <Row>
                        <Col md={4}>
                            <InputGroup>
                                <InputGroupText>
                                    Street
                                </InputGroupText>
                                <Input type="text" placeholder="Enter street" value={this.state.street} onChange={(e) => this.handleStreetChange(e)} />
                            </InputGroup>
                        </Col>

                        <Col md={4}>
                            <InputGroup>
                                <InputGroupText>
                                    City
                                </InputGroupText>
                                <Input type="text" placeholder="Enter city" value={this.state.city} onChange={(e) => this.handleCityChange(e)} />
                            </InputGroup>
                        </Col>

                        <Col md={4}>
                            <InputGroup>
                                <InputGroupText>
                                    Postal code
                                </InputGroupText>
                                <Input type="text" placeholder="Enter postal code" value={this.state.postalCode} onChange={(e) => this.handlePostalCodeChange(e)} />
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