import './App.css';
import React from 'react';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import { createRoutesFromElements, Route } from 'react-router';
import { Home } from 'pages/Home';
import { ContactDetails } from 'pages/ContactDetails';
import { Index } from 'pages/Index';

function App() {
  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route path="/" element={<Index />}>
        <Route index element={<Home />} />
        <Route path=":id" element={<ContactDetails />} />
      </Route>
    )
  )
  return (
    <>
      <RouterProvider router={router} />
    </>
  );
}

export default App;
