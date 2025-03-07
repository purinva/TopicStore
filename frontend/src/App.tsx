import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import './App.css'
import { Provider } from 'react-redux';
import { store } from './store/store.ts';
import { RequireAuth } from './helpers/RequireAuth.tsx';
import { TopicLayout } from './layouts/TopicLayout/TopicLayout.tsx';
import { TopicPage } from './pages/TopicPage/TopicPage.tsx';
import { AuthLayout } from './layouts/AuthLayout/AuthLayout.tsx';
import { LoginPage } from './pages/LoginPage/LoginPage.tsx';
import { ErrorLayout } from './layouts/ErrorLayout/ErrorLayout.tsx';
import { ErrorPage } from './pages/ErrorPage/ErrorPage.tsx';
import { RegisterPage } from './pages/RegisterPage/RegisterPage.tsx';
import { TopicByIdPage } from './pages/TopicByIdPage/TopicByIdPage.tsx';

const router = createBrowserRouter([
  {
    path: 'topic',
    element: <RequireAuth><TopicLayout/></RequireAuth>,
    children: [
      { path: '/', element: <TopicPage/> },
      { path: '/:topicId', element: <TopicByIdPage/> }, 
    ]
  },
  {
    path: '/auth',
    element: <AuthLayout/>,
    children: [
      { path: '/', element: <LoginPage/> }, 
      { path: 'register', element: <RegisterPage/> }
    ]
  },
  {
    path: "*",
    element: <ErrorLayout/>,
    children: [
      { path: '/', element: <ErrorPage/> },
    ]
  }
]);

export function App() {

  return (
      <Provider store={store}>
        <RouterProvider router={router} />
      </Provider>
  )
}