import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div>
            <NavMenu style={{ margin: 0 }} />
            <Container width={"100vw"}
            style={
            {
                margin: 0,
                padding: 0,
                //border: '2px solid red'
            }
        }>
          {this.props.children}
        </Container>
      </div>
    );
  }
}
