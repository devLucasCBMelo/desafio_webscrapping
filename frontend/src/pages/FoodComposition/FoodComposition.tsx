import { useEffect, useState } from "react";
import { Footer } from "../../components/Footer/Footer";
import { Header } from "../../components/Header/Header";
import { FoodCardList, FoodCompositionContainer, FoodCompositionMain, SearchBarContainer } from "./styles";
import { CardFoodType } from "../../types/FoodTypes";
import { fetchAllFoodList } from "../../utils/fetchAllFoodList";
import FoodCard from "../../components/FoodCard/FoodCard";
import { fetchFoodByCode } from "../../utils/fetchFoodByCode";

function FoodComposition() {
  const [foodCode, setFoodCode] = useState('');
  const [showFoodInfos, setShowFoodInfos] = useState<CardFoodType>({} as CardFoodType);
  const [foodList, setFoodList] = useState<CardFoodType[]>([]);

  useEffect(() => {
    const getFoodList = async () => {
      const data = await fetchAllFoodList();
      setFoodList(data);
    }

    getFoodList();
  }, [showFoodInfos])

  const handleSearchFood = async () => {
    const foundedFood = await fetchFoodByCode(foodCode)
    setShowFoodInfos(foundedFood);
  }

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
          <button onClick={() => handleSearchFood()}>Procurar</button>
        </SearchBarContainer>

        <FoodCardList>
          {showFoodInfos.codigo ? (
            <FoodCard codigo={showFoodInfos.codigo} nome={showFoodInfos.nome} nomeCientifico={showFoodInfos.nomeCientifico} grupo={showFoodInfos.grupo} marca={showFoodInfos.marca}/>
          ) : (
            foodList.map((food, key) => (
              <FoodCard key={key} codigo={food.codigo} nome={food.nome} nomeCientifico={food.nomeCientifico} grupo={food.grupo} marca={food.marca}/>
            ))
          )}
        </FoodCardList>
      </FoodCompositionMain>
      <Footer />
    </FoodCompositionContainer>
  )
}

export default FoodComposition;