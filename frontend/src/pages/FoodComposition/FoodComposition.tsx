import { useEffect, useState } from "react";
import { Footer } from "../../components/Footer/Footer";
import { Header } from "../../components/Header/Header";
import { FoodCardList, FoodCompositionContainer, FoodCompositionMain, LoadMoreCardsButton, SearchBarContainer } from "./styles";
import { CardFoodType } from "../../types/FoodTypes";
import { fetchAllFoodList } from "../../utils/fetchAllFoodList";
import FoodCard from "../../components/FoodCard/FoodCard";
import { fetchFoodByCode } from "../../utils/fetchFoodByCode";

function FoodComposition() {
  const [foodCode, setFoodCode] = useState('');
  const [filteredFoodList, setFilteredFoodList] = useState<CardFoodType[]>([]);
  const [foodList, setFoodList] = useState<CardFoodType[]>([]);
  const [page, setPage] = useState(0);
  const itemsPerPage = 15;

  useEffect(() => {
    const getFoodList = async () => {
      const data = await fetchAllFoodList();
      setFoodList(data);
    };

    getFoodList();
  }, []);

  const handleSearchFood = async () => {
    if (!foodCode.trim()) {
      setFilteredFoodList([]);
      return;
    }

    const searchResult = await fetchFoodByCode(foodCode);

    if (Array.isArray(searchResult)) {
      // Se o resultado for uma lista, exibir paginado
      setFilteredFoodList(searchResult);
      setPage(0);
    } else {
      // Se for um único item, exibir apenas ele
      setFilteredFoodList([searchResult]);
    }
  };

  const displayedList = filteredFoodList.length > 0 ? filteredFoodList : foodList;

  return (
    <FoodCompositionContainer>
      <Header />
      <FoodCompositionMain>
        <h3>Digite o código do alimento</h3>
        <p>Não encontrou o que procura? Digite o código abaixo</p>
        <SearchBarContainer>
          <input
            type="text"
            placeholder="Digite aqui o código do alimento"
            value={foodCode}
            onChange={(event) => setFoodCode(event.target.value)}
          />
          <button onClick={handleSearchFood}>Procurar</button>
        </SearchBarContainer>

        <FoodCardList>
          {displayedList.slice(0, (page + 1) * itemsPerPage).map((food) => (
            <FoodCard
              key={food.codigo}
              codigo={food.codigo}
              nome={food.nome}
              nomeCientifico={food.nomeCientifico}
              grupo={food.grupo}
              marca={food.marca}
            />
          ))}
        </FoodCardList>

        {(page + 1) * itemsPerPage < displayedList.length && (
          <LoadMoreCardsButton onClick={() => setPage(page + 1)}>Carregar mais</LoadMoreCardsButton>
        )}
      </FoodCompositionMain>
      <Footer />
    </FoodCompositionContainer>
  );
}

export default FoodComposition;
