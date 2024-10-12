import './App.css'
import {createBrowserRouter, RouterProvider} from "react-router-dom";
import Root from "./Root.tsx";
import UserInfoPage from "./pages/UserInfoPage/UserInfoPage.tsx";
import HomePage from "./pages/HomePage/HomePage.tsx";

const router = createBrowserRouter([
    {
        path: '/',
        element: <Root/>,
        children: [{
            index: true,
            element: <HomePage/>
        }, {
            path: 'user',
            children: [{
                path: 'info',
                element: <UserInfoPage/>
            }]
        }]
    }
])

function App() {
    return <RouterProvider router={router}/>
}

export default App
