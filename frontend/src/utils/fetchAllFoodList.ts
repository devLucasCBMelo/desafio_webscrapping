const HOST = import.meta.env.VITE_HOST || 'http://localhost:5032';

export const fetchAllFoodList = async () => {
  try {
    const response = await fetch(`${HOST}/Food`);
    const data = await response.json();
    return data;
  } catch (error) {
    console.log("Erro ao buscar todos os alimentos", error);
  }
}