import { Component } from 'react';

export class Counter extends Component<{}, { count: number }> {
    static displayName = Counter.name;

    state = { count: 0 };

    increment = () => {
        this.setState({
            count: this.state.count + 1
        });
    }

    render() {
        return (
            <div>
                <h1>Counter</h1>

                <p>This is a simple example of a React component.</p>

                <p aria-live="polite">Current count: <strong>{this.state.count}</strong></p>

                <button className="btn btn-primary" onClick={this.increment}>Increment</button>
            </div>
        );
    }
}
