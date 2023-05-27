import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import Head2Head from './components/Head2Head'
import Footer from './components/Footer'
import Header from './components/Header'

function App() {

  return (
    <>
      <div>
        <Header/>
        <Head2Head/>
        <Footer/>
      </div>
    </>
  )
}

export default App
