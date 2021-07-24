import React, { Component } from 'react'
import { Link } from 'react-router-dom';
import { List } from 'semantic-ui-react';
import axios from '../../axios'

class Movies extends Component {
    state = {
        names: []
    }

    componentDidMount() {
        axios.get('/movie/list').then(response => {
            console.log(response);
            if (response && response.data) {
                this.setState({ names: response.data })
            }
        })
    }


    render() {
        const names = this.state.names;
        return (
            <List>
                {!!names && names.length > 0 && names.map(name => (
                    <List.Item key={name}>
                        <Link to={`/movie/${name}`}>{name}</Link>
                    </List.Item>
                ))}
            </List>
        )
    }
}

export default Movies;