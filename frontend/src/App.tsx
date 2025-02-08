import { Route, Routes } from 'react-router-dom'
import Login from './pages/Login/Login'
import FoodComposition from './pages/FoodComposition/FoodComposition'
import ComponentInfosPage from './pages/ComponentInfosPage/ComponentInfosPage'


function App() {

  return (
    <Routes>
      <Route path='/' element={ <Login /> } />
      <Route path='/foodcomposition'  element={ <FoodComposition /> }/>
      <Route path='/foodcomponents' element={ <ComponentInfosPage /> } />
    </Routes>
  )
}

export default App
