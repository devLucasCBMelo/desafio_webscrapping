const HOST = import.meta.env.VITE_HOST || 'http://localhost:5032';

export const fetchFoodDatabase = async () => {
  try {
    const response = await fetch(`${HOST}/api/scraping/tbca`);
    const data = await response.json();
    return data;
  } catch (error) {
    console.log("Erro ao buscar popular a tabela Alimentos", error);
  }
}