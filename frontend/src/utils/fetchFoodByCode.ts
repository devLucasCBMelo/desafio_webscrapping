const HOST = import.meta.env.VITE_HOST || 'http://localhost:5032';

export const fetchFoodByCode = async (foodCode: string) => {
  try {
    const response = await fetch(`${HOST}/Food/${foodCode}`);
    const data = await response.json();
    return data;
  } catch (error) {
    console.log("Erro ao buscar alimento específico", error);
  }
}