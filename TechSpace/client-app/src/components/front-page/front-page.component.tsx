import React, { Component, ClassAttributes } from "react";
import "./front-page.scss";

export interface FrontPageComponentProps extends ClassAttributes<FrontPage> {
}

export interface FrontPageComponentState {
}

export class FrontPage extends Component<FrontPageComponentProps, FrontPageComponentState> {
    constructor(props: FrontPageComponentProps) {
        super(props);
        this.state = {};
    }

    render() {
        return (<div>Hello from front page!</div>);
    }
}