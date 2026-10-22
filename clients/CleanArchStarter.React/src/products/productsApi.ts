import type { Product } from './product.types'

export const apiBaseUrl = import.meta.env.VITE_API_BASE_URL as string

export async function fetchProducts(): Promise<Product[]> {
  const response = await fetch(`${apiBaseUrl}/api/products`)
  if (!response.ok) {
    throw new Error(`${response.status} ${response.statusText}`)
  }
  return response.json() as Promise<Product[]>
}
