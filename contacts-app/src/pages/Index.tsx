import { ContactCard } from 'components/ContactCard'
import { Navbar } from 'components/Navbar'
import React from 'react'
import { Outlet } from "react-router-dom"

export const Index = () => {
    return (
        <body className='min-h-screen pt-12 bg-slate-200 antialiased'>
            <Navbar />
            <div className='container max-w-7xl mx-auto h-full pt-12 bg-yellow-200'>
                <Outlet />
            </div>
        </body>
    )
}
