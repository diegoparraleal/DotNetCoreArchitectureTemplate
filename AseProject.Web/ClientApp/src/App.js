import React from 'react';
import { Route } from 'react-router';
import { Layout } from './components';
import { Todo } from './pages';

import './custom.css'
import {StoreProvider} from "./store";

export default function App() {
    return (
        <StoreProvider>
            <Layout>
                <Route exact path='/' component={Todo} />
                <Route path='/todo' component={Todo} />
            </Layout>      
        </StoreProvider>
    );
}
