import './App.css';
import 'semantic-ui-css/semantic.min.css'
import Layout from './hoc/Layout/Layout';
import { Redirect, Route, Switch } from 'react-router-dom';
import Movies from './containers/Movies/Movies';
import Movie from './containers/Movie/Movie';

function App() {
  return (
    <Layout>
      <Switch>
        <Route path="/movie/:name" component={Movie}></Route>
        <Route path="/movies" component={Movies}></Route>
        <Route path="/" exact component={Movies}></Route>
        <Redirect to="/" />
      </Switch>
    </Layout>
  );
}

export default App;
