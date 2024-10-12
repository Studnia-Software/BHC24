import './App.css'
import {createBrowserRouter, RouterProvider} from "react-router-dom";
import Root from "./Root.tsx";

const router = createBrowserRouter([
    {
        path: '/',
        element: <Root/>,
        children: [{
            index: true,
        }]
    }
])

function App() {
    return <RouterProvider router={router}/>
}

export default App
