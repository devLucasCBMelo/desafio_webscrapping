import styled from "styled-components";

export const FoodCompositionContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  min-height: 100vh;
`

export const FoodCompositionMain = styled.main`
  display: flex;
  flex-direction: column;
  align-items: center;
  flex: 1;
  margin-bottom: 20px;

  input {
    width: 200px;
  }
`

export const SearchBarContainer = styled.div`
  display: flex;
  flex-direction: row;
  margin-bottom: 30px;
`

export const FoodCardList = styled.div`
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
`