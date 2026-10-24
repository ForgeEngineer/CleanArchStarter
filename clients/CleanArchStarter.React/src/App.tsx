import ProductsPage from './pages/ProductsPage'
import CountriesPage from './pages/CountriesPage'
import { Routes, Route, Link } from 'react-router-dom'

export default function App() {
  return (
    <>
      <nav>
        <Link to="/">Products</Link>
        {' | '}
        <Link to="/countries">Countries</Link>
      </nav>

      <Routes>
        <Route path="/" element={<ProductsPage />} />
        <Route path="/countries" element={<CountriesPage />} />
      </Routes>
    </>
  )
}
