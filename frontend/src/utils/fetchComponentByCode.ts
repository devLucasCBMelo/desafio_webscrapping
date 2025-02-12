const HOST = import.meta.env.VITE_HOST || 'http://localhost:5032';

export const fetchComponentyCode = async (foodCode: string) => {
  try {
    const response = await fetch(`${HOST}/Component/${foodCode}`);
    const data = await response.json();
    return data;
  } catch (error) {
    console.log(`Erro ao buscar componente do alimento ${foodCode}`, error);
  }
}