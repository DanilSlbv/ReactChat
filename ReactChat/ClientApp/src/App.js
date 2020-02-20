import React, { Component } from 'react';
import LoadLogIn from './components/logIn/loadLogIn';

export default class App extends Component {
  static displayName = App.name;

  render () {
      return (
          <LoadLogIn></LoadLogIn>
    );
  }
}
