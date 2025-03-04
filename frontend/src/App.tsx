import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import './App.css'
import { Provider } from 'react-redux';
import { URL } from './config/config.ts';
import axios from 'axios';
import { store } from './store/store.ts';
import { RequireAuth } from './helpers/RequireAuth.tsx';
import { TopicLayout } from './layouts/TopicLayout.tsx';

  const router = createBrowserRouter([
    {
      path: '/topic',
      element: <RequireAuth><TopicLayout/></RequireAuth>,
      children: [
        {
          path: '/:id',
          element: <Topic/>,
          errorElement: <>Ошибка</>,
          loader: async ({ params }) => {
            try {
              const response = await axios
                .get(`${URL}/topic/${params.id}`);
              return response.data;
            }
            catch (error) {
              console.error('Ошибка загрузки топика:', error);
              throw new Response('Ошибка загрузки топика', { status: 500 });
            }
          }
        }
      ]
    },
    {
      path: '/auth',
		  element: <AuthLayout/>,
		  children: [
        { path: '/login', element: <Login/> }, 
        { path: '/register', element: <Register/> }
      ]
    }
  ]);

function App() {

  return (
      <Provider store={store}>
        <RouterProvider router={router} />
      </Provider>
  )
}

export default App;