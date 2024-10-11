document.addEventListener("DOMContentLoaded", function () {
    const homeBanner = document.getElementById("home-banner");
    const selectionSection = document.getElementById("selection-section");
    const placeOrderButton = document.getElementById("place-order");
    const confirmationSection = document.getElementById("confirmation-section");

    const brothOptionsContainer = document.getElementById("broth-options");
    const proteinOptionsContainer = document.getElementById("protein-options");

    let selectedBroth = null;
    let selectedProtein = null;
    
    const brothImages = {
        "1": "assets/images/lamen-salt.png",
        "2": "assets/images/lamen-soy.png", 
        "3": "assets/images/lamen-miso.png" 
    };

    homeBanner.addEventListener("click", function () {
        homeBanner.style.display = "none"; 
        selectionSection.style.display = "block"; 
        loadBrothOptions(); 
        loadProteinOptions(); 
    });

    placeOrderButton.addEventListener("click", function () {
        if (selectedBroth && selectedProtein) {            
            localStorage.setItem("selectedBrothId", selectedBroth);
            realizarPedido(selectedBroth, selectedProtein);
        } else {
            alert("Please select both a broth and a protein.");
        }
    });

    function createCard(item, type) {
        return `
            <div class="card ${type}-card" data-id="${item.id}" data-price="${item.price}" data-active="${item.imageActive}" data-inactive="${item.imageInactive}">
                <img src="${item.imageInactive || 'assets/default-image.png'}" alt="${item.name}" />
                <span id="item-title">${item.name}</span>
                <span id="item-desc">${item.description}</span>
                <span id="item-price">US$ ${item.price}</span>
            </div>
        `;
    }

    function loadBrothOptions() {
        fetch("https://ramengo-49427ced9460.herokuapp.com/Caldo", {
            headers: {
                 "X-API-KEY": "ZtVdh8XQ2U8pWI2gmZ7f796Vh8GllXoN7mr0djNf"
            }
        })  
            .then(response => response.json())
            .then(data => {
                brothOptionsContainer.innerHTML = data.map(item => createCard(item, "broth")).join("");
                setCardSelection("broth");
            })
            .catch(error => console.error("Erro ao carregar os caldos:", error));
    }

    function loadProteinOptions() {
        fetch("https://ramengo-49427ced9460.herokuapp.com/Proteina", {
            headers: {
                 "X-API-KEY": "ZtVdh8XQ2U8pWI2gmZ7f796Vh8GllXoN7mr0djNf"
            }
        }) 
            .then(response => response.json())
            .then(data => {
                proteinOptionsContainer.innerHTML = data.map(item => createCard(item, "protein")).join("");
                setCardSelection("protein");
            })
            .catch(error => console.error("Erro ao carregar as proteínas:", error));
    }

    function setCardSelection(type) {
        const cards = document.querySelectorAll(`.${type}-card`);
        cards.forEach(card => {
            card.addEventListener("click", () => {
                cards.forEach(c => {
                    c.classList.remove("selected");
                    c.querySelector("img").src = c.dataset.inactive; 
                });
                card.classList.add("selected");
                card.querySelector("img").src = card.dataset.active; 
                if (type === "broth") selectedBroth = card.dataset.id;
                if (type === "protein") selectedProtein = card.dataset.id;
            });
        });
    }

    function realizarPedido(caldoId, proteinaId) {
        fetch("https://ramengo-49427ced9460.herokuapp.com/Pedido/Realizar", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "X-API-KEY": "ZtVdh8XQ2U8pWI2gmZ7f796Vh8GllXoN7mr0djNf"
            },
            body: JSON.stringify({ caldoId: caldoId, proteinaId: proteinaId })
        })
            .then(response => response.json())
            .then(data => {
                mostrarConfirmacao(data.pedidoId, data.descricao);
            })
            .catch(error => console.error("Erro ao realizar pedido:", error));
    }

    function mostrarConfirmacao(pedidoId, descricao) {
        selectionSection.style.display = "none"; 
        confirmationSection.style.display = "block"; 

        const orderSummary = document.querySelector("#order-summary h2");
        const orderDescription = document.querySelector("#order-summary .order-description");
        const ramenImage = document.querySelector("#order-summary img");
        
        const selectedBrothId = localStorage.getItem("selectedBrothId");
        if (selectedBrothId && brothImages[selectedBrothId]) {
            ramenImage.src = brothImages[selectedBrothId];
        }

        orderSummary.textContent = `Your Order: ${pedidoId}`;
        orderDescription.textContent = descricao;
    }
});