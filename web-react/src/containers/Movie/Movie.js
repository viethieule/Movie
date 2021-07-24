import React, { Component } from 'react';
import styles from './Movie.module.css'

class Movie extends Component {
    render() {
        let name = this.props.match.params.name;

        return (
            <video className={styles.player} controls crossOrigin="anonymous">
                <source src={`https://localhost:44375/api/movie/media/${name}`} type="video/mp4" />
                <track src={`https://localhost:44375/api/movie/subtitle/${name}`} srcLang="en" label="English" default />
            </video>
        )
    }
}

export default Movie;