using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Domain.Services.Communication;
using LearningCenter.API.Shared.Domain.Repositories;

namespace LearningCenter.API.Learning.Services;

public class TutorialService : ITutorialService
{
    private readonly ITutorialRepository _tutorialRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryRepository _categoryRepository;

    public TutorialService(ITutorialRepository tutorialRepository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
    {
        _tutorialRepository = tutorialRepository;
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
    }


    public async Task<IEnumerable<Tutorial>> ListAsync()
    {
        return await _tutorialRepository.ListAsync();
    }

    public async Task<IEnumerable<Tutorial>> ListByCategoryIdAsync(int categoryId)
    {
        return await _tutorialRepository.FindByCategoryIdAsync(categoryId);
    }

    public async Task<TutorialResponse> SaveAsync(Tutorial tutorial)
    {
        // Validate Category Id

        var existingCategory = _categoryRepository.FindByIdAsync(tutorial.CategoryId);

        if (existingCategory == null)
            return new TutorialResponse("Invalid Category");
        
        // Validate Title

        var existingTutorialWithTitle = await _tutorialRepository.FindByTitleAsync(tutorial.Title);

        if (existingTutorialWithTitle != null)
            return new TutorialResponse("Tutorial Title already exists");

        try
        {
            await _tutorialRepository.AddAsync(tutorial);
            await _unitOfWork.CompleteAsync();

            return new TutorialResponse(tutorial);
        }
        catch (Exception e)
        {
            return new TutorialResponse($"An error occurred while saving the tutorial: {e.Message}");
        }

    }

    public async Task<TutorialResponse> UpdateAsync(int tutorialId, Tutorial tutorial)
    {
        var existingTutorial = await _tutorialRepository.FindByIdAsync(tutorialId);
        
        // Validate Tutorial Id

        if (existingTutorial == null)
            return new TutorialResponse("Tutorial not found.");

        // Validate Category Id

        var existingCategory = _categoryRepository.FindByIdAsync(tutorial.CategoryId);

        if (existingCategory == null)
            return new TutorialResponse("Invalid Category");
        
        // Validate Title

        var existingTutorialWithTitle = await _tutorialRepository.FindByTitleAsync(tutorial.Title);

        if (existingTutorialWithTitle != null && existingTutorialWithTitle.Id != existingTutorial.Id)
            return new TutorialResponse("Tutorial Title already exists");

        existingTutorial.Title = tutorial.Title;
        existingTutorial.Description = tutorial.Description;
        existingTutorial.CategoryId = tutorial.CategoryId;

        try
        {
            _tutorialRepository.Update(existingTutorial);
            await _unitOfWork.CompleteAsync();

            return new TutorialResponse(existingTutorial);
        }
        catch (Exception e)
        {
            return new TutorialResponse($"An error occurred while updating the tutorial: {e.Message}");
        }
    }

    public async Task<TutorialResponse> DeleteAsync(int tutorialId)
    {
        var existingTutorial = await _tutorialRepository.FindByIdAsync(tutorialId);

        if (existingTutorial == null)
            return new TutorialResponse("Tutorial not found.");

        try
        {
            _tutorialRepository.Remove(existingTutorial);
            await _unitOfWork.CompleteAsync();

            return new TutorialResponse(existingTutorial);
        }
        catch (Exception e)
        {
            return new TutorialResponse($"An error occurred while deleting the tutorial: {e.Message}");
        }
    }
}