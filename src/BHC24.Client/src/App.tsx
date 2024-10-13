import './App.css'
import {createBrowserRouter, RouterProvider} from "react-router-dom";
import Root from "./Root.tsx";
import HomePage from "./pages/HomePage/HomePage.tsx";
import {LoginPage} from './pages/Auth/Login/LoginPage.tsx';
import {QueryClient, QueryClientProvider} from '@tanstack/react-query';
import {RegisterPage} from './pages/Auth/Register/RegisterPage.tsx';
import {ProfilePage} from './pages/Profile/ProfilePage.tsx';
import {ProjectSearch} from './pages/ProjectSearch/ProjectSearch.tsx';

const router = createBrowserRouter([
  {
    path: '/',
    element: <Root/>,
    children: [
      {
        index: true,
        element: <HomePage/>
      },
      {
        path: 'auth',
        children: [{
          index: true,
          element: <LoginPage/>
        },
          {
            path: 'login',
            element: <LoginPage/>
          },
          {
            path: 'register',
            element: <RegisterPage/>
          }
        ]
      },
      {
        path: 'profile/:id',
        element: <ProfilePage/>
      },
      {
        path: 'projects',
        element: <ProjectSearch/>
      }
    ]
  }
]);

const queryClient = new QueryClient();

function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <RouterProvider router={router}/>
    </QueryClientProvider>
  );
}

export default App
