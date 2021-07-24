import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Container, Menu } from 'semantic-ui-react';

class Layout extends Component {
    render() {
        return (
            <div>
                <Menu fixed="top">
                    <Container>
                        <Menu.Item link header>
                            <Link to="/">Netfix</Link>
                        </Menu.Item>
                        <Menu.Item link>
                            <Link to="/">Home</Link>
                        </Menu.Item>
                    </Container>
                </Menu>
                <Container style={{ marginTop: "6em" }}>
                    {this.props.children}
                </Container>
            </div>
        )
    }
}

export default Layout;