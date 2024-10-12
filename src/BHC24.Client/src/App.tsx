import './App.css'
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import Root from "./Root.tsx";
import UserInfoPage from "./pages/UserInfoPage/UserInfoPage.tsx";
import HomePage from "./pages/HomePage/HomePage.tsx";
import { LoginPage } from './pages/Login/LoginPage.tsx';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';

const router = createBrowserRouter([
  {
    path: '/',
    element: <Root />,
    children: [
      {
        index: true,
        element: <HomePage />
      },
      {
        path: 'auth',
        children: [
          {
            path: 'login',
            element: <LoginPage />
          }
        ]
      },
      {
        path: 'user/:id',
        children: [
          {
            path: 'info',
            element: <UserInfoPage />
          }
        ]
      }
    ]
  }
])

const queryClient = new QueryClient()

function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <RouterProvider router={router} />
    </QueryClientProvider>
  );
}

export default App
