import { Route, Routes } from 'react-router-dom'
import Login from './pages/Login/Login'
import FoodComposition from './pages/FoodComposition/FoodComposition'


function App() {

  return (
    <Routes>
      <Route path='/' element={ <Login /> } />
      <Route path='/foodcomposition'  element={ <FoodComposition /> }/>
    </Routes>
  )
}

export default App
