import { useEffect, useState } from 'react'
import type { Product } from './product.types'
import { apiBaseUrl, fetchProducts } from './productsApi'

const fmt = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' })

export default function ProductsTable() {
  const [products, setProducts] = useState<Product[]>([])
  const [loading, setLoading] = useState(true)
  const [error, setError] = useState('')

  useEffect(() => {
    fetchProducts()
      .then(setProducts)
      .catch(() =>
        setError(`Failed to load products. Make sure the API is running on ${apiBaseUrl}.`)
      )
      .finally(() => setLoading(false))
  }, [])

  if (loading) return <p className="status">Loading&#x2026;</p>
  if (error)   return <p className="error">{error}</p>

  async function reloadProducts() {
    const data = await fetchProducts();
    setProducts(data);
  }

  return (
    <div>
    <table>
      <thead>
        <tr>
          <th>Id</th>
          <th>Name</th>
          <th>Price</th>
        </tr>
      </thead>
      <tbody>
        {products.map(p => (
          <tr key={p.id}>
            <td>{p.id}</td>
            <td>{p.name}</td>
            <td>{fmt.format(p.price)}</td>
          </tr>
        ))}
      </tbody>
    </table>  
      <button onClick={reloadProducts}>
      Refresh
    </button>
     </div>
  )
}
