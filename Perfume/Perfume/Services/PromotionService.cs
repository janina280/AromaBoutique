﻿using DataBaseLayout.Models;
using Perfume.Models;
using Perfume.Repositories.Interfaces;
using Perfume.Services.Interfaces;

namespace Perfume.Services
{
    public class PromotionService: IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IImageConvertorService _imageConvertorService;

        public PromotionService(IPromotionRepository promotionRepository, IImageConvertorService imageConvertorService)
        {
            _promotionRepository = promotionRepository;
            _imageConvertorService = imageConvertorService;
        }
        public async Task<List<PromotionModel>> GetPromotionsAsync()
        {
            var promotions = await _promotionRepository.GetPromotionsAsync();
            var promotionsDto=new List<PromotionModel>();
            foreach (var promotion in promotions)
            {
                var img = await _imageConvertorService.ConvertByteArrayToFileFormAsync(new ImageDto()
                {FileName = promotion.FileName,
                    Image = promotion.Image,
                    ImageName = promotion.ImageName

                });

                promotionsDto.Add(new PromotionModel()
                {
                    Description = promotion.Description,
                    Image = await _imageConvertorService.ConvertFormFileToImageAsync(img)
                });
            }
            return promotionsDto;
        }

        public async Task AddPromotionAsync(AddPromotionModel model)
        {
            var promotion = new Promotion()
            {
                Description = model.Description,
                Image = await _imageConvertorService.ConvertFileFormToByteArrayAsync(model.Image),

            };
            await _promotionRepository.CreatePromotionAsync(promotion);
        }
    }
}