import './App.css'
import ErrorPage from './components/ErrorPage';
import { Head2Head } from './components/Head2Head'
import LoginPage from './components/LoginPage'
import { Navbar } from './components/Navbar'
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";

const router = createBrowserRouter([
  {
    path: "/",
    element: <LoginPage/>,
    errorElement:<ErrorPage/>
  },
  {
    path: "/Head2Head",
    element: 
      <Head2Head/>
  },
  {
    path: "/ErrorPage",
    element: <ErrorPage/>

  }
]);

function App() {

  return (
    <>
    <Navbar/>
    {/* <Head2Head/> */}
    <RouterProvider router={router} />
    </>
  )
}

export default App
