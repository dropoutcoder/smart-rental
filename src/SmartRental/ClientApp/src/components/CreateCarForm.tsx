import { ChangeEvent, Component, FormEvent } from "react";
import { Button, Col, Container, Form, Input, InputGroup, InputGroupText, Label, Row } from "reactstrap";
import ApiClient from "../http/ApiClient";
import ICar from "../http/data/ICar";
import ICreateCar from "../http/inputs/ICreateCar";

export default class CreateCarForm extends Component<{ onCreated: (value: ICar) => void }, ICreateCar> {
    static defaultState = {
        name: '',
        registrationNumber: ''
    };

    state = CreateCarForm.defaultState;

    handleNameChange(event: ChangeEvent<HTMLInputElement>): void {
        this.setState({
            name: event.target.value
        });
    }

    handleRegistrationNumberChange(event: ChangeEvent<HTMLInputElement>): void {
        this.setState({
            registrationNumber: event.target.value
        });
    }

    handleSubmit(event: FormEvent<HTMLFormElement>): void {
        event.preventDefault();

        ApiClient.createCar(this.state)
            .then(value => {
                console.log(JSON.stringify(value));
                this.props.onCreated(value);
                this.setState(CreateCarForm.defaultState);
            })
            .catch((error: Error) => {
                alert(error.message);
            });
    }

    render() {
        return (
            <Form onSubmit={(e) => this.handleSubmit(e)}>
                <Container className="d-grid gap-3">
                    <Row className="row-cols-lg-auto g-3 align-items-center">
                        <Col>
                            <InputGroup>
                                <InputGroupText>
                                    Name
                                </InputGroupText>
                                <Input type="text" placeholder="Enter name" value={this.state.name} onChange={(e) => this.handleNameChange(e)} />
                            </InputGroup>
                        </Col>

                        <Col>
                            <InputGroup>
                                <InputGroupText>
                                    Registration number
                                </InputGroupText>
                                <Input type="text" placeholder="Enter registration number" value={this.state.registrationNumber} onChange={(e) => this.handleRegistrationNumberChange(e)} />
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