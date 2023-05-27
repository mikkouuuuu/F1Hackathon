import React from 'react'
import reactLogo from '../assets/react.svg'
import viteLogo from '/vite.svg'

export const Navbar = () => {
  return (
    <div className="text-white h-12 flex grid-cols-3">
        <h1 className='text-4xl'>Sup</h1>
        <a href="https://vitejs.dev" target="_blank" rel="noopener noreferrer">
            <img src={viteLogo} className="w-10 h-10" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank" rel="noopener noreferrer">
            <img src={reactLogo} className="w-10 h-10" alt="React logo" />
        </a>
    </div>


  )
}
